echo 'start pack'
nuget pack ../Package.nuspec
echo 'start upload'
NuGetPackageUploader .