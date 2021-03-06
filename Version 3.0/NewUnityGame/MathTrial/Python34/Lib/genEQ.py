import os
from sympy import *
import matplotlib
matplotlib.use('Agg')
import matplotlib.pyplot 
from sympy.parsing.sympy_parser import parse_expr
from pylab import *

def genPNG(expr, rColor, gColor, bColor, aColor, res, ResourceFolder, filename):
	rColor = float(rColor)
	gColor = float(gColor)
	bColor = float(bColor)
	aColor = 1 - float(aColor)
	#ResourceFolder = 'Equation Images'
	expr = sympify(expr, evaluate = False)
	texexpr = latex(expr)
	fig = matplotlib.pyplot.figure(1)
	matplotlib.pyplot.text(0, 0, r"$%s$" % texexpr, fontsize = 100, color = (rColor, gColor, bColor), alpha = aColor)
	ax = matplotlib.pyplot.gca()
	fig.set_size_inches(0.01, 0.01)
	ax.axes.get_xaxis().set_visible(False)
	ax.axes.get_yaxis().set_visible(False)
	ax.axis('off')
	matplotlib.pyplot.savefig(os.getcwd() + '/Assets/Resources/' + ResourceFolder + '/' + filename, transparent = True, frameon = False, bbox_inches = 'tight', pad_inches = 0.5)
	matplotlib.pyplot.close('all')
	return filename