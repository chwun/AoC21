import { readFileSync } from 'fs';

const file = readFileSync('resources/inputData.txt', 'utf-8');
const lines = file.split('\r\n');

const signalPatterns: string[][] = [];
const outputValues: string[][] = [];

for (const line of lines) {
  const lineInputParts = line.split(' | ');
  signalPatterns.push(lineInputParts[0].split(' '));
  outputValues.push(lineInputParts[1].split(' '));
}

DoPart1(outputValues);
DoPart2(signalPatterns, outputValues);

function DoPart1(outputValues: string[][]) {
  const allOutputValues = outputValues.flat();
  const validLengths = [2, 3, 4, 7];
  const resultPart1 = allOutputValues.filter((x) => validLengths.includes(x.length)).length;

  console.log(`Part 1: result: ${resultPart1}`);
}

// really bad implementation, but works...
function DoPart2(signalPatterns: string[][], outputValues: string[][]) {
  const resultNumbers: number[] = [];

  for (let i = 0; i < signalPatterns.length; i++) {
    const currentSignalPatterns = signalPatterns[i].map((x) => x.split('').sort().join(''));

    const segments1 = PopUniqueSegmentsByLength(currentSignalPatterns, 2);
    const segments4 = PopUniqueSegmentsByLength(currentSignalPatterns, 4);
    const segments7 = PopUniqueSegmentsByLength(currentSignalPatterns, 3);
    const segments8 = PopUniqueSegmentsByLength(currentSignalPatterns, 7);

    const patternsWith5Segments = PopMultipleSegmentsByLength(currentSignalPatterns, 5);

    const segments3 = PopUniqueSegmentsByIncludedSegments(patternsWith5Segments, segments1);
    const segments5 = PopUniqueSegmentsByNumberOfMatchingSegmentParts(
      patternsWith5Segments,
      segments4.split(''),
      3
    );
    const segments2 = patternsWith5Segments[0];

    const patternsWith6Segments = PopMultipleSegmentsByLength(currentSignalPatterns, 6);

    const segments9 = PopUniqueSegmentsByIncludedSegments(patternsWith6Segments, segments4);
    const segments0 = PopUniqueSegmentsByIncludedSegments(patternsWith6Segments, segments1);
    const segments6 = patternsWith6Segments[0];

    const mapping = new Map<string, string>([
      [segments0, '0'],
      [segments1, '1'],
      [segments2, '2'],
      [segments3, '3'],
      [segments4, '4'],
      [segments5, '5'],
      [segments6, '6'],
      [segments7, '7'],
      [segments8, '8'],
      [segments9, '9'],
    ]);

    let numberString = '';

    for (const outputValue of outputValues[i]) {
      numberString += mapping.get(outputValue.split('').sort().join(''));
    }

    resultNumbers.push(Number(numberString));
  }

  const sum = resultNumbers.reduce((partial_sum, x) => partial_sum + x, 0);
  console.log(`Part 2: result sum: ${sum}`);
}

function PopUniqueSegmentsByLength(currentSignalPatterns: string[], length: number): string {
  const segments = currentSignalPatterns.find((x) => x.length === length) ?? '';
  const indexOfSegments = currentSignalPatterns.indexOf(segments);

  currentSignalPatterns.splice(indexOfSegments, 1);

  return segments.split('').sort().join('');
}

function PopMultipleSegmentsByLength(currentSignalPatterns: string[], length: number): string[] {
  const indicesToPop: number[] = [];
  const resultSegments: string[] = [];

  currentSignalPatterns.forEach((val, index) => {
    if (val.length === length) {
      resultSegments.push(val.split('').sort().join(''));
      indicesToPop.push(index);
    }
  });

  indicesToPop.reverse().forEach((indexToPop) => currentSignalPatterns.splice(indexToPop, 1));

  return resultSegments;
}

function PopUniqueSegmentsByIncludedSegments(
  currentSignalPatterns: string[],
  includedSegments: string
): string {
  for (const pattern of currentSignalPatterns) {
    const patternSegments = pattern.split('');
    let allIncluded = true;
    for (const segment of includedSegments.split('')) {
      if (!patternSegments.includes(segment)) {
        allIncluded = false;
        break;
      }
    }

    if (allIncluded) {
      const indexOfPattern = currentSignalPatterns.indexOf(pattern);
      currentSignalPatterns.splice(indexOfPattern, 1);

      return pattern;
    }
  }

  return '';
}

function PopUniqueSegmentsByNumberOfMatchingSegmentParts(
  currentSignalPatterns: string[],
  compareSegmentParts: string[],
  numberOfMatchingSegmentParts: number
): string {
  for (const pattern of currentSignalPatterns) {
    const patternSegments = pattern.split('');
    let numberOfMatchingParts = 0;
    for (const segment of compareSegmentParts) {
      if (patternSegments.includes(segment)) {
        numberOfMatchingParts++;
      }
    }

    if (numberOfMatchingParts === numberOfMatchingSegmentParts) {
      const indexOfPattern = currentSignalPatterns.indexOf(pattern);
      currentSignalPatterns.splice(indexOfPattern, 1);

      return pattern;
    }
  }

  return '';
}
