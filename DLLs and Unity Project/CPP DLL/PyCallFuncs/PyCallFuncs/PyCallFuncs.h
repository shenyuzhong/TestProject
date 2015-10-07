#ifdef PYFUNCDLL_EXPORT
#define PYFUNCDLL_API __declspec(dllexport)
#else
#define PYFUNCDLL_API __declspec(dllexport)
#endif

extern "C"
{
	PYFUNCDLL_API void PyCall(char* pyName, char* pyFunc, char* result, int varCount, ...);
	
	// This function MUST be called before any other functions are called. 
	PYFUNCDLL_API void PyInit();

	// This function should be called last. If called in the Unity editor Unity will crash on the second play.
	PYFUNCDLL_API void PyFin();

}