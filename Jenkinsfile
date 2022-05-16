pipeline {
    agent any
    environment {
        COMMITMSG = sh(returnStdout: true, script: "git log -1 --oneline")  
      }
    stages {
        stage("Startup"){
            steps {
                buildDescription env.COMMITMSG
                script{
                  try {
                    sh "rm -rf TestResults"
                  } finally {}
                }
            }
        }
        stage("Build") {
            when {
                anyOf {
                    changeset "riv4lz-api/**"
                }
            }
            steps {
              dir("riv4lz-api/riv4lz.casterApi") {
                sh "dotnet build --configuration Release"
              }
            }
            post{
                success{
                    // archiveArtifacts("bin/**")
                    echo "Build succeded"
                }
                failure{
                    echo "Build failed"
                }
            }
        } 
        stage("Test"){
            when {
                anyOf {
                    changeset "riv4lz-api/**"
                }
            }
            steps{
                dir("riv4lz-api/riv4lz.casterApi") {
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"  
                } 
            }
            post{
                success{
                    archiveArtifacts "TestResults/*/coverage.cobertura.xml"
                    publishCoverage adapters: [cobertura(path: 'TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE')
                }
            }
        }
        stage("Clean Containers"){
            steps{
                script{
                    try{
                        sh "docker-compose down"
                    }
                    finally{}
                }
            }
        }
        stage("Deploy") {
            steps {
                sh "docker-compose up -d" 
            }
        }         
    }
}