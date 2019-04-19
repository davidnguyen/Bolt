$param = $args[0]
$msbuild = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe"
$solutionName = "Zeus"

try {
	Write-Host "Building $solutionName solution..." -ForegroundColor Green
	& $msbuild "$solutionName.sln" -nr:false -v:m $param

	if ($LastExitCode -eq 0) {
		Write-Host "Solution build complete." -ForegroundColor Green
	} else {
		Write-Host "Solution build fails." -ForegroundColor Red
	}
}
catch {
    Write-Host "Unhandled exception: $($_.Exception.GetType().FullName) - ($_.Exception.Message)" -ForegroundColor Red
}