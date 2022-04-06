pipeline {
    agent any
    environment {
        AWS_ACCOUNT_ID="508498738919"
        AWS_DEFAULT_REGION="us-east-1" 
        IMAGE_REPO_NAME="credor"
        IMAGE_TAG="latest"
        REPOSITORY_URI = "${AWS_ACCOUNT_ID}.dkr.ecr.${AWS_DEFAULT_REGION}.amazonaws.com/${IMAGE_REPO_NAME}"
    }
   
    stages {
        
         stage('Logging into AWS ECR') {
            steps {
                script {
                sh "aws ecr get-login-password --region ${AWS_DEFAULT_REGION} | docker login --username AWS --password-stdin ${AWS_ACCOUNT_ID}.dkr.ecr.${AWS_DEFAULT_REGION}.amazonaws.com"
                }
                 
            }
        }
        
        stage('Cloning Git') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/master']], extensions: [], userRemoteConfigs: [[credentialsId: 'a20503ad-5039-4327-b838-da091265f708', url: 'https://github.com/Aswinkumarsivanandam/Credor-updated.git']]])
            }
        }
        // move to path
        stage('jsonfile path') {
             steps{  
                script {
                    sh "cd /var/lib/jenkins/workspace/credor-fb/Frontend"
                 }
            }
        }
    // Npm install
        stage('Install') {
            steps{  
                script {
                    dir ('/var/lib/jenkins/workspace/credor-fb/Frontend') {
                        sh 'npm install'
                    }
                }
            }
        }
      
    // Ng Date time
        stage('Date-time NG') {
             steps{  
                script {
                    sh "npm i ng-pick-datetime"
                 }
            }
        }
    // NPM build
        stage('Build') {
             steps{  
                script {
                    sh "ng build"
                 }
            }
        }
    // Copying Dist/Credor to dockfiles
        stage('Copying build files') {
            steps{  
                script {
                    sh "cp -r /var/lib/jenkins/workspace/credor-fb/dist dockfiles/"
                }
            }
        }
  
    // Building Docker images
        stage('Building image') {
            steps{
                script {
                    dockerImage = docker.build "${IMAGE_REPO_NAME}:${IMAGE_TAG}"
                }
            }
        }
   // deleting Old Dock files
        stage('deleting Dock files') {
             steps{  
                 script {
                    sh "rm -r dockfiles/dist"
                }
            }
        }
    // Uploading Docker images into AWS ECR
        stage('Docker Run') {
            steps{  
                script {
                    sh "docker build -t credor-fb ."
                }
            }
        }
    }
}
