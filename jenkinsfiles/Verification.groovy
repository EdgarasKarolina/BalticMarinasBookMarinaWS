node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat '"C:/Program Files/Nuget/bin/nuget.exe" restore BalticMarinasBookMarinaWS.sln'
		bat "\"${MSBuild}\" BalticMarinasBookMarinaWS.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
	
	stage 'Archive'
		archive 'BalticMarinasBookMarinaWS/bin/Release/**'
}