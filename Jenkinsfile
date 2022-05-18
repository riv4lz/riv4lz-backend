pipeline {
    agent any
    environment {
        COMMITMSG = sh(returnStdout: true, script: "git log -1 --oneline")  
      }
    stages {
        stage("Startup"){
            steps {
                buildDescription env.COMMITMSG
                dir("riv4lz-api/riv4lz.casterApi"){
                    script{
                        try {
                            sh "rm -rf TestResults"
                        } finally {}
                    }
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
              sh "docker-compose --env-file Dev.env build api"
              sh "docker-compose --env-file Dev.env build redis"
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
             echo "test"
            }
            /*
            parallel{
              stage("Test-Api"){
                steps{
                  dir("riv4lz-api/riv4lz.casterApi.test") {
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"  
                  }
                }
              }
              stage("Test-Security"){
                steps{
                  dir("riv4lz-api/riv4lz.security.test") {
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"  
                  }
                }
              }
              stage("Test-Core"){
                steps{
                  dir("riv4lz-api/riv4lz.core.test") {
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"  
                  }
                }
              }
            }
            post{
                success{
                    //archiveArtifacts "riv4lz-api/riv4lz.casterApi.test/TestResults/*/coverage.cobertura.xml"
                    publishCoverage adapters: [cobertura(path: 'riv4lz-api/riv4lz.casterApi.test/TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE') 
                    publishCoverage adapters: [cobertura(path: 'riv4lz-api/riv4lz.core.test/TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE') 
                    publishCoverage adapters: [cobertura(path: 'riv4lz-api/riv4lz.security.test/TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE') 
                    
                    echo "Test succeded"
                }
            } */
        }
        stage("Clean Containers"){
            steps{
                script{
                    try{
                        sh "docker-compose --env-file Dev.env down"
                    }
                    finally{}
                }
            }
        }
        stage("Deploy") {
            steps {
                sh "docker-compose --env-file Dev.env up -d" 
            }
        }
        stage("Push images to registry"){
          steps{
            withCredentials([usernamePassword(credentialsId: 'ACR', passwordVariable: 'PASSWORD', usernameVariable: 'USERNAME')]) {
              sh 'docker login -u ${USERNAME} -p ${PASSWORD} riv4lzprod.azurecr.io'
              sh "docker-compose --env-file Dev.env build"
              //sh "docker tag redis:latest riv4lzprod.azurecr.io:redis-${BUILD_NUMBER}"
              //sh "docker tag postgres:latest riv4lzprod.azurecr.io:postgres-${BUILD_NUMBER}"
              //sh "docker push riv4lzprod.azurecr.io:redis-${BUILD_NUMBER}"
              //sh "docker push riv4lzprod.azurecr.io:postgres-${BUILD_NUMBER}"
              sh "docker-compose --env-file Dev.env push"
            }
          } 
        }         
    }
}