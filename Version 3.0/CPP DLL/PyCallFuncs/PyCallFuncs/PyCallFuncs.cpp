#include "PyCallFuncs.h"
#include <Python.h>
#include <string>
#include <stdarg.h>

extern "C"
{
	void PyCall(char* pyName, char* pyFunc, char* result, int varCount, ...)
	{
		
		PyObject *pName, *pModule, *pFunc;
		PyObject *pArgs, *pValue;

		char * tempResult = 0;

		pName = PyUnicode_FromString(pyName);

		pModule = PyImport_Import(pName);
		Py_DECREF(pName);

		if (pModule != NULL)
		{
			pFunc = PyObject_GetAttrString(pModule, pyFunc);

			va_list varList;
			va_start(varList, varCount);

			if (pFunc && PyCallable_Check(pFunc))
			{
				pArgs = PyTuple_New(varCount);

				for (int i = 0; i < varCount; i++)
				{
					pValue = PyUnicode_FromString(va_arg(varList, char*));
					PyTuple_SetItem(pArgs, i, pValue);
				}

				va_end(varList);

				pValue = PyObject_CallObject(pFunc, pArgs);

				Py_DECREF(pArgs);

				if (pValue != NULL)
				{
					Py_DECREF(pValue);
				}
				if (PyUnicode_Check(pValue))
				{
					PyObject * tempObj = PyUnicode_AsEncodedString(pValue, "ASCII", "strict");
					if (tempObj != NULL)
					{
						tempResult = PyBytes_AsString(tempObj);
						strcpy(result, tempResult);

						Py_DECREF(tempObj);
					}
				}
			}
		}

	}

	void PyInit()
	{
		wchar_t searchPath[] = L"Python34";
		Py_SetPythonHome(searchPath);
		Py_Initialize();
	}

	void PyFin()
	{
		Py_Finalize();
	}

	
}