#include <windows.h>

void main()
{
	char i;
	HKEY hKey;
	DWORD port;

	RegOpenKeyEx(HKEY_LOCAL_MACHINE, TEXT("SOFTWARE\\MCFR\\KozaDisk"), NULL, KEY_READ, &hKey);

	DWORD size = sizeof(DWORD);
	RegQueryValueEx(hKey, TEXT("InstallPath"), NULL, NULL, (BYTE *)&port, &size);

	MessageBox(NULL, TEXT("Hello"), TEXT("test"), NULL);
}