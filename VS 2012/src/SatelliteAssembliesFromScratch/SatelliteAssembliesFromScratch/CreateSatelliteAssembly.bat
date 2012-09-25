resgen "es\SatelliteAssembliesFromScratch.MyResources.es.txt"
al /t:lib /culture:es /embed:"es\SatelliteAssembliesFromScratch.MyResources.es.resources" /out:"es\SatelliteAssembliesFromScratch.resources.dll"
xcopy "es\SatelliteAssembliesFromScratch.resources.dll" "..\..\..\WebApplication1\bin\es" /Y