resgen.exe "es\GlobalResources.txt" "es\Msts.Domain.GlobalResources.es.resources"
al.exe /t:lib /embed:"es\Msts.Domain.GlobalResources.es.resources" /culture:es /out:"es\Msts.Domain.resources.dll"
xcopy "es\Msts.Domain.resources.dll" "..\..\..\Msts\bin\es" /Y