
#include <windows.h>
#include <stdio.h>
#include <string>

extern "C" {
	typedef void(_stdcall* LPEXTFUNCRESPOND) (LPCSTR s);

	struct RGBE {
		int R;
		int G;
		int B;
	};
	 __declspec(dllexport) RGBE* GetPixelAtCursor(void)
	{
		FARPROC procGetPixel; //Declare Callback Function

		HINSTANCE _hGDI = LoadLibrary("gdi32.dll"); // Handle für GDI Libary

		if (_hGDI)
		{
			procGetPixel = GetProcAddress(_hGDI, "GetPixel"); // Gets address of Exported function GET PIXEL
			HDC _hdc = GetDC(NULL); // Handle for Display Drawing

			if (_hdc)
			{
				POINT _cursorPosition;
				GetCursorPos(&_cursorPosition);
				COLORREF _color = GetPixel(_hdc, _cursorPosition.x, _cursorPosition.y);
				int _r = GetRValue(_color);
				int _g = GetGValue(_color);
				int _b = GetBValue(_color);
				FreeLibrary(_hGDI);
				RGBE *er = new RGBE();
				er->R = _r;
				er->G = _g;
				er->B = _b;

				return er;

			}
			FreeLibrary(_hGDI);
		}

	}
}