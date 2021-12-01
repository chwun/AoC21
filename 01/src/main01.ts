import { readFileSync } from 'fs'
import { Part1 } from './part1'
import { Part2 } from './part2'

const file = readFileSync('resources/inputData.txt', 'utf-8')
const lines = file.split('\r\n')

const part1 = new Part1()
const increasedMeasurements1 = part1.calculate(lines)

const part2 = new Part2()
const increasedMeasurements2 = part2.calculate(lines)

console.log(`Part 1: Number of increased measurements: ${increasedMeasurements1}`)
console.log(`Part 2: Number of increased measurements: ${increasedMeasurements2}`)
