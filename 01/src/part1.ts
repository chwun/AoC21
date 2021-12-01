export class Part1 {
  calculate(lines: string[]): number {
    const values = lines.map((x) => Number(x))
    let numberOfIncreasedMeasurements = 0

    values.forEach((value, index) => {
      if (index >= 1) {
        if (value > values[index - 1]) {
          numberOfIncreasedMeasurements++
        }
      }
    })

    return numberOfIncreasedMeasurements
  }
}
