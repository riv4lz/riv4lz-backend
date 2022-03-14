module.exports = {
  name: 'rfc3986',
  moduleFileExtensions: ['ts', 'js'],
  verbose: true,
  collectCoverageFrom: ['<rootDir>/index.ts'],
  transform: { '^.+\\.(ts)$': 'babel-jest', },
  testMatch: [ '<rootDir>/index.test.ts' ],
  testEnvironment: 'node'
}
