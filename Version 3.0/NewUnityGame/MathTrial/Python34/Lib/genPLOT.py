import os
from sympy import *
import matplotlib
matplotlib.use('Agg')
import matplotlib.pyplot 
from sympy.parsing.sympy_parser import parse_expr
from pylab import *

def genAXES(xL, xU, yL, yU, rColor, gColor, bColor, aColor, res, ResourceFolder, filename):
	rColor = float(rColor)
	gColor = float(gColor)
	bColor = float(bColor)
	aColor = 1 - float(aColor)

	xL = float(xL)
	xU = float(xU)
	yL = float(yL)
	yU = float(yU)

	lAxesPos = (0 - xL)/(xU - xL)
	bAxesPos = (0 - yL)/(yU - yL)

	fig = matplotlib.pyplot.figure(1)
	
	ax = fig.add_subplot(1,1,1)
	ax.grid(color = (bColor, gColor, rColor), linewidth = 2)
	ax.axis([xL, xU, yL, yU])
	ax.spines['left'].set_position(("axes",lAxesPos))
	ax.spines['left'].set_color((bColor, gColor, rColor))
	ax.spines['right'].set_visible(False)
	ax.spines['bottom'].set_position(("axes",bAxesPos))
	ax.spines['bottom'].set_color((bColor, gColor, rColor))
	ax.spines['top'].set_visible(False)
	ax.patch.set_alpha(0)
	ax.set_xticks(arange(xL, xU, 1))
	ax.set_yticks(arange(yL, yU, 1))
	
	matplotlib.pyplot.savefig(os.getcwd() + '/Assets/Resources/' + ResourceFolder + '/' + filename, transparent = True, frameon = False, bbox_inches = 'tight', pad_inches = 0)
	matplotlib.pyplot.close('all')
	return filename

def genPLOT(expr, var, xStart, xStop, xStep, xPoint, rColor, gColor, bColor, aColor, res, ResourceFolder, filename):
	rColor = float(rColor)
	gColor = float(gColor)
	bColor = float(bColor)
	aColor = 1 - float(aColor)

	xStart = float(xStart)
	xStop = float(xStop)
	xStep = float(xStep)

	xPoint = float(xPoint)
	
	#ResourceFolder = 'Equation Images'
	
	expr = sympify(expr)
	var = Symbol(var)
	func = lambdify(var, expr)

	t = arange(xStart, xStop, xStep)

	fig = matplotlib.pyplot.figure(1)
	
	ax = fig.add_subplot(1,1,1)
	ax.axis([-10, 10, -10, 10])
	ax.patch.set_alpha(0)
	
	ax.plot(t, func(t), color = (rColor, gColor, bColor), linewidth = 3)
	hold(True)
	ax.plot(xPoint, func(xPoint), 'o', markersize = 10, markerfacecolor = (bColor, gColor, rColor))
	ax.axis('off')
	matplotlib.pyplot.savefig(os.getcwd() + '/Assets/Resources/' + ResourceFolder + '/' + filename, transparent = True, frameon = False, bbox_inches = 'tight', pad_inches = 0)
	matplotlib.pyplot.close('all')
	return filename