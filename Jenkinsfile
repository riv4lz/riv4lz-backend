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
                dir("riv4lz-api/riv4lz.core"){
                    script{
                        try {
                            sh "rm -rf TestResults"
                        } finally {}
                    }
                }
                dir("riv4lz-api/riv4lz.dataAccess"){
                    script{
                        try {
                            sh "rm -rf TestResults"
                        } finally {}
                    }
                }
                dir("riv4lz-api/riv4lz.mediatr"){
                    script{
                        try {
                            sh "rm -rf TestResults"
                        } finally {}
                    }
                }
                dir("riv4lz-api/riv4lz.security"){
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
              stage("Test-Mediator"){
                steps{
                  dir("riv4lz-api/riv4lz.mediatr.test") {
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"  
                  }
                }
              }
              stage("Test-Infrastructure"){
                steps{
                  dir("riv4lz-api/riv4lz.dataAccess.test") {
                    sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"  
                  }
                }
              }
            }
            post{
                success{
                   publishCoverage adapters: [cobertura(path: 'riv4lz-api/riv4lz.casterApi.test/TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE') 
                   publishCoverage adapters: [cobertura(path: 'riv4lz-api/riv4lz.core.test/TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE') 
                   publishCoverage adapters: [cobertura(path: 'riv4lz-api/riv4lz.security.test/TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE') 
                   publishCoverage adapters: [cobertura(path: 'riv4lz-api/riv4lz.mediatr.test/TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE')
                   publishCoverage adapters: [cobertura(path: 'riv4lz-api/riv4lz.dataAccess.test/TestResults/*/coverage.cobertura.xml', thresholds: [[thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE') 
                   echo "Test succeded"
                }
            }
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
        stage("Push to Azure Container Registry") {
            steps{
            withCredentials([usernamePassword(credentialsId: 'ACR', passwordVariable: 'PASSWORD', usernameVariable: 'USERNAME')]) {
              sh 'docker login -u ${USERNAME} -p ${PASSWORD} riv4lzprod.azurecr.io'
              sh "docker-compose --env-file Prod.env build"
              sh "docker push riv4lzprod.azurecr.io/api:${BUILD_NUMBER}"
            }
          }
        }         
    }
}