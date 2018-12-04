node {
	stage 'Checkout'
		checkout scm

	stage 'Test'
		bat "\"${MSBuild}\" /t:Restore BalticMarinasBookMarinaWS.sln"
		bat returnStatus: true, script: "\"C:/Program Files/dotnet/dotnet.exe\" test \"C:/Users/Edgaras/Desktop/Final Project/BalticMarinas/BalticMarinasBookMarinaWS/BalticMarinasBookMarinaWS.sln\" --logger \"trx;LogFileName=unit_tests.xml\" --no-build"
	
	stage 'Archive'
		archive 'BalticMarinasBookMarinaWS/bin/Release/**'
}