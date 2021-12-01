export class Part2 {
  calculate(lines: string[]) {
    const windows = this.createSlidingMeasurements(lines)
    return this.processMeasurements(windows)
  }

  private createSlidingMeasurements(lines: string[]): number[] {
    const values = lines.map((x) => Number(x))
    const slidingMeasurements: number[] = []

    values.forEach((value, index) => {
      if (index >= 2) {
        const sum = values[index - 2] + values[index - 1] + values[index]
        slidingMeasurements.push(sum)
      }
    })

    return slidingMeasurements
  }

  private processMeasurements(measurements: number[]): number {
    let numberOfIncreasedMeasurements = 0

    measurements.forEach((value, index) => {
      if (index >= 1) {
        if (value > measurements[index - 1]) {
          numberOfIncreasedMeasurements++
        }
      }
    })

    return numberOfIncreasedMeasurements
  }
}
