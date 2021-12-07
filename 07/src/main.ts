import { readFileSync } from 'fs';

const file = readFileSync('resources/inputData.txt', 'utf-8');
const numbers = file.split(',').map((x) => Number(x));

const min = Math.min(...numbers);
const max = Math.max(...numbers);

let currentMinFuelSumPart1 = Number.MAX_VALUE;
let currentTargetPosPart1 = 0;
let currentMinFuelSumPart2 = Number.MAX_VALUE;
let currentTargetPosPart2 = 0;

for (let i = min; i < max; i++) {
  let fuelSumPart1 = 0;
  let fuelSumPart2 = 0;

  for (const number of numbers) {
    const diff = Math.abs(number - i);

    fuelSumPart1 += diff;
    fuelSumPart2 += (diff * (diff + 1)) / 2;
  }

  if (fuelSumPart1 < currentMinFuelSumPart1) {
    currentMinFuelSumPart1 = fuelSumPart1;
    currentTargetPosPart1 = i;
  }

  if (fuelSumPart2 < currentMinFuelSumPart2) {
    currentMinFuelSumPart2 = fuelSumPart2;
    currentTargetPosPart2 = i;
  }
}

console.log(`Part 1: target pos: ${currentTargetPosPart1}, fuel sum: ${currentMinFuelSumPart1}`);
console.log(`Part 2: target pos: ${currentTargetPosPart2}, fuel sum: ${currentMinFuelSumPart2}`);
