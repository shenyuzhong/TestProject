from sympy import *
#from sympy.parsing.sympy_parser import parse_expr
#from sympy.printing import print_ccode, str

def pydiff(a, b):
	a = sympify(a)
	b = sympify(b)
	return str(diff(a, b))
	
#def pyint(a, b):
#	a = sympify(a)
#	b = sympify(b)
#	return str(integrate(a, b))