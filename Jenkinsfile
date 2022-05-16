pipeline {
    agent any
    stages {
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
              //sh "docker build . -t frederikotto/riv4lz-backend:${BUILD_NUMBER}"
            }
        }
        stage("Deliver") {
            steps {
                    withCredentials([usernamePassword(credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD')]) {
                        sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                        //sh "docker push frederikotto/riv4lz-backend:${BUILD_NUMBER}"
                        }
            }
        }
        stage("Production") {
            steps {
              //sh "docker run -d --rm -p 7219:7219  --name riv4lz-backend frederikotto/riv4lz-backend:${BUILD_NUMBER}"
            }
        }
    }
}