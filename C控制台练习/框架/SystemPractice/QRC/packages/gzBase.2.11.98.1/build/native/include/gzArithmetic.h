//******************************************************************************
//
// Copyright (C) SAAB AB
//
// All rights, including the copyright, to the computer program(s)
// herein belong to SAAB AB. The program(s) may be used and/or
// copied only with the written permission of SAAB AB, or in
// accordance with the terms and conditions stipulated in the
// agreement/contract under which the program(s) have been
// supplied.
//
//
// Information Class:	COMPANY UNCLASSIFIED
// Defence Secrecy:		NOT CLASSIFIED
// Export Control:		NOT EXPORT CONTROLLED
//
//
// File			: gzArithmetic.h
// Module		: gzBase
// Description	: Class definition of Atrimetics used.
// Author		: Anders Modén		
// Product		: GizmoBase 2.11.98
//		
//
//			
// NOTE:	GizmoBase is a platform abstraction utility layer for C++. It contains 
//			design patterns and C++ solutions for the advanced programmer.
//
//
// Revision History...							
//									
// Who	Date	Description						
//									
// AMO	180919	Created file 	
//
//******************************************************************************

#ifndef __GZ_ARITHMETIC_H__
#define __GZ_ARITHMETIC_H__

#include "gzBasicTypes.h"

/*!	\file 
	\brief Arithmetic utilites 

	Used Arithmetic is double and float
*/

// Forward prototyp
GZ_BASE_EXPORT gzVoid throwFatalTemplateError(const char* string);

// ******************** class definitions ***************************************

template <class T> class  gzAritmetic_
{
public:

	static T epsilon();
	static T maxval();
	static T minval();
};

// -------------------------- gzFloat ------------------------------------------

typedef gzAritmetic_<gzFloat>	gzAritmetic;

template <> inline gzFloat gzAritmetic::epsilon()
{
	return	20 * FLT_EPSILON;		// Relative precision
}

template <> inline gzFloat gzAritmetic::maxval()
{
	return	FLT_MAX;
}

template <> inline gzFloat gzAritmetic::minval()
{
	return	FLT_MIN;
}

// ------------------------ gzDouble ------------------------------------------

typedef gzAritmetic_<gzDouble>	gzAritmeticD;

template <> inline gzDouble gzAritmeticD::epsilon()
{
	return	20 * DBL_EPSILON;		// Relative precision
}

template <> inline gzDouble gzAritmeticD::maxval()
{
	return	DBL_MAX;
}

template <> inline gzDouble gzAritmeticD::minval()
{
	return	DBL_MIN;
}

// --------- Common used math functions -----------------

// ---------------------- sin ---------------------------

template <class T> inline T sin(const T& value)
{
	return ::sin(value);
}

template <> inline gzDouble sin(const gzDouble& value)
{
	return ::sin(value);
}

template <> inline gzFloat sin(const gzFloat& value)
{
	return ::sinf(value);
}

// ---------------------- cos ---------------------------

template <class T> inline T cos(const T& value)
{
	return ::cos(value);
}

template <> inline gzDouble cos(const gzDouble& value)
{
	return ::cos(value);
}

template <> inline gzFloat cos(const gzFloat& value)
{
	return ::cosf(value);
}

// ---------------------- tan ---------------------------

template <class T> inline T tan(const T& value)
{
	return ::tan(value);
}

template <> inline gzDouble tan(const gzDouble& value)
{
	return ::tan(value);
}

template <> inline gzFloat tan(const gzFloat& value)
{
	return ::tanf(value);
}

// ---------------------- atan2 ---------------------------

template <class T> inline T atan2(const T& y, const T& x)
{
	return ::atan2(y,x);
}

template <> inline gzDouble atan2(const gzDouble& y, const gzDouble& x)
{
	return ::atan2(y,x);
}

template <> inline gzFloat atan2(const gzFloat& y, const gzFloat& x)
{
	return ::atan2f(y,x);
}

// ---------------------- gzAbs ---------------------------

template <class T> inline T gzAbs(const T& value)
{
	return (value >= 0) ? value : -value;
}

// Branchless abs value

template <> inline gzFloat gzAbs(const gzFloat& val)
{

#if defined WIN32 && !defined WIN64 && !defined GZ_WIN64

	gzFloat output;

	__asm
	{
		mov         eax, val
		mov			eax, [eax]
		and eax, 7FFFFFFFh
		mov			output, eax
	}

	return (output);

#else
		
	union
	{
		gzInt32	l;
		gzFloat f;
	} u;

	u.f = val;
	u.l &= 0x7FFFFFFF;

	return u.f;

#endif

}

template <> inline gzDouble gzAbs(const gzDouble& val)
{
#if defined WIN32 && !defined WIN64  && !defined GZ_WIN64

	gzDouble output;

	__asm
	{
		mov         eax, val
		fld			qword ptr[eax]
		fabs
		fstp		output
	}
	return (output);

#else

	union
	{
		gzInt64	ll;
		gzDouble	d;
	} u;

	u.d = val;
	u.ll &= LLU(0x7FFFFFFFFFFFFFFF);

	return u.d;

#endif

}

// ---------------------- gzSqrt ---------------------------

template <class T> inline T gzSqrt(const T& a)
{
	return ::sqrt(a);
}

template <> inline gzFloat gzSqrt(const gzFloat& a)
{
	if (a < 0)
		throwFatalTemplateError("sqrt on negative number");

	return sqrtf(a);
}

template <> inline gzUInt32 gzSqrt(const gzUInt32& a)
{
	return (gzUInt32)sqrtf((gzFloat)a);
}

template <> inline gzDouble gzSqrt(const gzDouble& a)
{
	if (a < 0)
		throwFatalTemplateError("sqrt on negative number");

	return sqrt(a);
}

// ---------------------- gzSq2 ---------------------------

template <class T> inline T gzSq2(const T& a)
{
	return a * a;
}

#endif // __GZ_ARITHMETIC_H__
