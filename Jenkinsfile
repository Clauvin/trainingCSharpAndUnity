UNITY = "%%unity%%"
DOTNET = '%dotnet%'
SCANNER_HOME = '%scannerhome%'
pipeline {
		parameters {
			choice(name: 'build', choices: ['Release', 'Debug'], description: "Release or Debug. Debug Builds take longer")
			choice(name: 'release', choices: ['alpha', 'beta', 'release'], description: "alpha - risky builds that may crash, beta - more mature builds testing before release release - builds ready for deployment to user")    
		}
	agent any 
		
		environment {
			appname = "MyGame"
			release_name = "${ "${release}" == "alpha" || "${release}" == "beta" ? "${release}" : "" }" 
			target = "${ "${build}" == "Release" ? "${appname}${release_name}.exe" : " ${appname}_Debug_${release_name}.exe" }" // append debug for debug builds, nothing for release builds
		}
	stages {
			stage ('Build') {
			steps { script {
				bat ' 'C:/Program Files/Unity/Hub/Editor/2020.3.16f1/Editor/unity.exe' -nographics -buildTarget Win64 -quit -batchmode -projectPath . -executeMethod JenkinsBuild.CommandLineParser.parseCommandLineArgs ${build} -buildWindows64Player "${target}"'
			}}}
			stage('SonarQube') { 
			steps { script {
				def scannerHome = "${SCANNER_HOME}"
				withSonarQubeEnv("SonarQubeScanner") { script {
				  bat """
					set /p login_token=<C:\\.env
					\"${DOTNET_PATH}\" ${scannerHome}\\SonarScanner.MSBuild.dll begin /key:MyGame /d:sonar.login=%login_token%
					\"${DOTNET_PATH}\" build  My
	Game.sln
					\"${DOTNET_PATH}\" ${scannerHome}\\SonarScanner.MSBuild.dll end /d:sonar.login=%login_token%
				  """
				}}}
			}}
	} // end stages
}