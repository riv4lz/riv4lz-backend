pipeline {
    agent any
    triggers{
      pollSCM("*/10 * * * *")
    }
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
                    echo "Build succeded"
                }
                failure{
                    discordSend description: "Build Stage FAILED", footer: "Please correct errors", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: "https://discord.com/api/webhooks/958687917100892181/Ywqi7Cv9vZ9UTFwvP9vezRxnBgWo_iXHhzFqNWqG8pv0i1gRyT3kiCihM09JOn4KB0le"
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
                failure{
                  discordSend description: "Test Stage FAILED", footer: "Please correct errors", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: "https://discord.com/api/webhooks/958687917100892181/Ywqi7Cv9vZ9UTFwvP9vezRxnBgWo_iXHhzFqNWqG8pv0i1gRyT3kiCihM09JOn4KB0le"
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
        stage("Deploy to Test Environment") {
            steps {
                sh "docker-compose --env-file Dev.env up -d" 
            }
            post{
              failure{
              discordSend description: "Deploy Stage FAILED", footer: "Please correct errors", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: "https://discord.com/api/webhooks/958687917100892181/Ywqi7Cv9vZ9UTFwvP9vezRxnBgWo_iXHhzFqNWqG8pv0i1gRyT3kiCihM09JOn4KB0le"
              }
              success{
                discordSend description: "Successfully deployed!", footer: "Great job!", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: "https://discord.com/api/webhooks/958687917100892181/Ywqi7Cv9vZ9UTFwvP9vezRxnBgWo_iXHhzFqNWqG8pv0i1gRyT3kiCihM09JOn4KB0le"
              }
            }
        }
        stage("Push to local Registry") {
            steps{
              sh "docker-compose --env-file Dev.env push"
            }
            post{
              failure{
                discordSend description: "Push Stage FAILED", footer: "Please correct errors", link: env.BUILD_URL, result: currentBuild.currentResult, title: JOB_NAME, webhookURL: "https://discord.com/api/webhooks/958687917100892181/Ywqi7Cv9vZ9UTFwvP9vezRxnBgWo_iXHhzFqNWqG8pv0i1gRyT3kiCihM09JOn4KB0le"
              }
            }
        }         
    }
}