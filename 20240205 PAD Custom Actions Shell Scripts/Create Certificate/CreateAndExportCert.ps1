$certname = "PaCustomActionsCert"
$cert = New-SelfSignedCertificate -Type "CodeSigningCert" -Subject "CN=$certname" -CertStoreLocation "Cert:\CurrentUser\My" -KeyExportPolicy Exportable -KeySpec Signature -KeyLength 2048 -KeyAlgorithm RSA -HashAlgorithm SHA256
$password = ConvertTo-SecureString 'FOA2025' -AsPlainText -Force
Export-Certificate -Cert $cert -FilePath "D:\MyProjects\Power Automate Desktop\Custom Actions\Certificates\$certname.pfx"