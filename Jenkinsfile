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
                sh "sudo dotnet build --configuration Release"
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
            steps{
              echo "Testing"
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
        stage("Push images to registry"){
          steps{
            withCredentials([usernamePassword(credentialsId: 'ACR', passwordVariable: 'PASSWORD', usernameVariable: 'USERNAME')]) {
              sh 'docker login -u ${USERNAME} -p ${PASSWORD} riv4lzprod.azurecr.io'
              sh "docker-compose --env-file Dev.env build"
              sh "docker push riv4lzprod.azurecr.io/api:${BUILD_NUMBER}"
            }
          } 
        }         
    }
}