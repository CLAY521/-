//*****************************************************************************
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
// File			: gzDynamicTypes.h
// Module		: gzCoordinate
// Description	: Class definition of coordinate transforms types
// Author		: Anders Modén		
// Product		: GizmoBase 2.11.98
//		
// Copyright © 2010- SAAB AB, Sweden
//			
// NOTE:	GizmoBase is a platform abstraction utility layer for C++. It contains 
//			design patterns and C++ solutions for the advanced programmer.
//
//
// Revision History...							
//									
// Who	Date	Description						
//									
// AMO	180215	Created file								(2.9.1)
//
//******************************************************************************
#ifndef __GZ_DYNAMIC_TYPES_H__
#define __GZ_DYNAMIC_TYPES_H__

/*!	\file 
	\brief Dynamic Coordinate transformations types

	This file provides utilities to translate between various simple coordinate systems

*/

#include "gzCoordinateTypes.h"

// ------------------------ LatPos -------------------------------------------------------------

const gzUInt16 GZ_DYNAMIC_TYPE_LATPOS_UNIQUE_ID = 30;		// gzGraph ends at 64,  Uses range 30-33

const gzString	GZ_DYNAMIC_TYPE_LATPOS = gzUniqueString("LatPos", GZ_DYNAMIC_TYPE_LATPOS_UNIQUE_ID);


class gzDynamicTypeLatPos : public gzSerializeData,
							public gzLatPos
{
public:

	gzDynamicTypeLatPos(const gzLatPos & pos = gzLatPos({ 0,0,0 })) : gzLatPos(pos) {}

	GZ_DECLARE_SERIALIZE_3(GZ_DYNAMIC_TYPE_LATPOS, latitude, longitude, altitude);
};

GZ_DECLARE_DYNAMIC_CUSTOM_TYPE(gzDynamicTypeLatPos);
GZ_DECLARE_DYNAMIC_CUSTOM_TYPE_NATIVE(gzDynamicTypeLatPos, gzLatPos);
GZ_DECLARE_DYNAMIC_CUSTOM_TYPE_NATIVE_UNPACK(gzDynamicTypeLatPos, gzLatPos);

// ------------------------- CartPos ------------------------------------------------------------

const gzUInt16 GZ_DYNAMIC_TYPE_CARTPOS_UNIQUE_ID = 31;		

const gzString	GZ_DYNAMIC_TYPE_CARTPOS = gzUniqueString("CartPos", GZ_DYNAMIC_TYPE_CARTPOS_UNIQUE_ID);


class gzDynamicTypeCartPos : public gzSerializeData,
							 public gzCartPos
{
public:

	gzDynamicTypeCartPos(const gzCartPos & pos = gzCartPos({ 0,0,0 })) : gzCartPos(pos) {}

	GZ_DECLARE_SERIALIZE_3(GZ_DYNAMIC_TYPE_CARTPOS, x,y,z);
};

GZ_DECLARE_DYNAMIC_CUSTOM_TYPE(gzDynamicTypeCartPos);
GZ_DECLARE_DYNAMIC_CUSTOM_TYPE_NATIVE(gzDynamicTypeCartPos, gzCartPos);
GZ_DECLARE_DYNAMIC_CUSTOM_TYPE_NATIVE_UNPACK(gzDynamicTypeCartPos, gzCartPos);

// ------------------------- ProjPos ------------------------------------------------------------

const gzUInt16 GZ_DYNAMIC_TYPE_PROJPOS_UNIQUE_ID = 32;

const gzString	GZ_DYNAMIC_TYPE_PROJPOS = gzUniqueString("ProjPos", GZ_DYNAMIC_TYPE_PROJPOS_UNIQUE_ID);


class gzDynamicTypeProjPos : public gzSerializeData,
						     public gzProjPos
{
public:

	gzDynamicTypeProjPos(const gzProjPos & pos = gzProjPos({ 0,0,0 })) : gzProjPos(pos) {}

	GZ_DECLARE_SERIALIZE_3(GZ_DYNAMIC_TYPE_PROJPOS, x, y, h);
};

GZ_DECLARE_DYNAMIC_CUSTOM_TYPE(gzDynamicTypeProjPos);
GZ_DECLARE_DYNAMIC_CUSTOM_TYPE_NATIVE(gzDynamicTypeProjPos, gzProjPos);
GZ_DECLARE_DYNAMIC_CUSTOM_TYPE_NATIVE_UNPACK(gzDynamicTypeProjPos, gzProjPos);

// ------------------------- UTMPos ------------------------------------------------------------

const gzUInt16 GZ_DYNAMIC_TYPE_UTMPOS_UNIQUE_ID = 33;

const gzString	GZ_DYNAMIC_TYPE_UTMPOS = gzUniqueString("UTMPos", GZ_DYNAMIC_TYPE_UTMPOS_UNIQUE_ID);


class gzDynamicTypeUTMPos : public gzSerializeData,
							public gzUTMPos
{
public:

	gzDynamicTypeUTMPos(const gzUTMPos & pos = gzUTMPos({ 0,0,0,0,0 })) : gzUTMPos(pos) {}

	GZ_DECLARE_SERIALIZE_5(GZ_DYNAMIC_TYPE_UTMPOS, zone,north,northing,easting,h);
};

GZ_DECLARE_DYNAMIC_CUSTOM_TYPE(gzDynamicTypeUTMPos);
GZ_DECLARE_DYNAMIC_CUSTOM_TYPE_NATIVE(gzDynamicTypeUTMPos, gzUTMPos);
GZ_DECLARE_DYNAMIC_CUSTOM_TYPE_NATIVE_UNPACK(gzDynamicTypeUTMPos, gzUTMPos);

GZ_COORDINATE_EXPORT gzVoid gzRegisterDynamicCoordinateTypes();
GZ_COORDINATE_EXPORT gzVoid gzUnregisterDynamicCoordinateTypes();

GZ_COORDINATE_EXPORT gzVoid gzSetLatPosEncodeInfo(gzSerializeAdapter* adapter, gzStreamEncoding encoding = GZ_STREAM_DUPLEX_ENCODING, gzDouble latitudePrecision = DBL_EPSILON, gzDouble longitudePrecision = DBL_EPSILON,gzDouble altitudePrecision = DBL_EPSILON, gzLatPos startEncodeValue = { 0,0,0 });
GZ_COORDINATE_EXPORT gzVoid gzSetCartPosEncodeInfo(gzSerializeAdapter* adapter, gzStreamEncoding encoding= GZ_STREAM_DUPLEX_ENCODING, gzDouble XPrecision = DBL_EPSILON, gzDouble YPrecision = DBL_EPSILON, gzDouble ZPrecision = DBL_EPSILON, gzCartPos startEncodeValue = { 0,0,0 });


#endif // __GZ_DYNAMIC_TYPES_H__







