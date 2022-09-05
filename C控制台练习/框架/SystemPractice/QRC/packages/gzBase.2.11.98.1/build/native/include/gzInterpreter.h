// *****************************************************************************
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
// File			: gzInterpreter.h
// Module		: gzBase
// Description	: Class definition of interpreter utilities
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
// AMO	150707	Created file 									(2.8.1)
//
// ******************************************************************************
#ifndef __GZ_INTERPRETER_H__
#define __GZ_INTERPRETER_H__

/*!	\file 
	\brief Interpreter utilities

Uses BNF to create a generic interpreter class

*/

#include "gzLex.h"

enum gzParseHttpState
{
	GZ_HTTP_PARSE_STATE_RESET,
	GZ_HTTP_PARSE_STATE_PUBLIC,
	GZ_HTTP_PARSE_STATE_LAST
};

enum gzSerializeHttpState
{
	GZ_HTTP_SERIALIZE_STATE_IDLE,
	GZ_HTTP_SERIALIZE_STATE_READ,
	GZ_HTTP_SERIALIZE_STATE_WRITE,
};

class gzInterpreterDataInterface 
{
public:

	GZ_BASE_EXPORT virtual ~gzInterpreterDataInterface(){};

	GZ_BASE_EXPORT	virtual gzVoid push(gzUByte *adress,gzUInt32 len);

	GZ_BASE_EXPORT	virtual gzVoid push(gzUByte data);

	GZ_BASE_EXPORT	virtual gzVoid quit();
};

//******************************************************************************
// Class	: gzInterpreter
//									
// Purpose  : Class for interpreting a BNF based syntax and execute callbacks
//									
// Notes	: 
//									
// Revision History...							
//									
// Who	Date	Description						
//									
// AMO	150707	Created 
//									
//******************************************************************************
class gzInterpreter :	public gzReference,
						public gzInterpreterDataInterface, 
						public gzThread,
						public gzBasicParser
{
public:

	GZ_DECLARE_TYPE_INTERFACE_EXPORT(GZ_BASE_EXPORT);
	
	GZ_BASE_EXPORT	gzInterpreter();

	GZ_BASE_EXPORT	virtual ~gzInterpreter();

	GZ_PROPERTY_EXPORT(gzString,	StartRuleName,	GZ_BASE_EXPORT);

	GZ_PROPERTY_EXPORT(gzBool,		SkipToLF,		GZ_BASE_EXPORT);

	// ---------- Parse utils --------------

	GZ_BASE_EXPORT	gzParseResult fQuit();

	// -------- iface ---------------------

	GZ_BASE_EXPORT	virtual gzVoid push(gzUByte *adress,gzUInt32 len) override;

	GZ_BASE_EXPORT	virtual gzVoid push(gzUByte data) override;

	GZ_BASE_EXPORT	virtual gzVoid quit() override;

	GZ_BASE_EXPORT	virtual gzParseResult parseRule(const gzString &rule);

	// ----------- Response iface --------------------

	GZ_BASE_EXPORT gzVoid setResponseInterface(gzInterpreterDataInterface *response);

protected:

	GZ_BASE_EXPORT	virtual gzVoid process() override;

	GZ_BASE_EXPORT	virtual gzVoid onNoMatch(){};
	GZ_BASE_EXPORT	virtual gzVoid onError(){};
	GZ_BASE_EXPORT	virtual gzVoid onOK(){};

	gzSerializeAdapterMuxPtr	m_adapter;

	gzInterpreterDataInterface	*m_response;
};

GZ_DECLARE_REFPTR(gzInterpreter);

//******************************************************************************
// Class	: gzFTPInterpreter
//									
// Purpose  : Class for interpreting a BNF based syntax and execute callbacks
//									
// Notes	: 
//									
// Revision History...							
//									
// Who	Date	Description						
//									
// AMO	150707	Created 
//									
//******************************************************************************
class gzFTPInterpreter : public gzParserFunction<gzFTPInterpreter,gzInterpreter>
						 
{
public:

	GZ_DECLARE_TYPE_INTERFACE_EXPORT(GZ_BASE_EXPORT);
	
	GZ_BASE_EXPORT	gzFTPInterpreter();

	GZ_BASE_EXPORT	virtual ~gzFTPInterpreter();

	// ---------- Parse utils --------------

	GZ_BASE_EXPORT	gzParseResult fUser();
	GZ_BASE_EXPORT	gzParseResult fPassword();
	GZ_BASE_EXPORT	gzParseResult fAuth();
	GZ_BASE_EXPORT	gzParseResult fSyst();
	GZ_BASE_EXPORT	gzParseResult fStart();
	GZ_BASE_EXPORT	gzParseResult fStop();

	GZ_BASE_EXPORT virtual gzParseResult parseRule(const gzString &rule) override;

	GZ_PROPERTY_EXPORT(gzString,	User,		GZ_BASE_EXPORT);
	GZ_PROPERTY_EXPORT(gzString,	Password,	GZ_BASE_EXPORT);

	GZ_BASE_EXPORT virtual gzBool usePassword()		{ return TRUE; }
	GZ_BASE_EXPORT virtual gzBool checkUser()		{ return TRUE; }
	GZ_BASE_EXPORT virtual gzBool checkPassword()	{ return TRUE; }

private:

	gzBool	m_sentResponse;
};

GZ_DECLARE_REFPTR(gzFTPInterpreter);

//******************************************************************************
// Class	: gzHTTPInterpreter
//									
// Purpose  : Class for interpreting a BNF based syntax and execute callbacks
//									
// Notes	: 
//									
// Revision History...							
//									
// Who	Date	Description						
//									
// AMO	190207	Created 
//									
//******************************************************************************
class gzHTTPInterpreter : public gzParserFunction<gzHTTPInterpreter, gzInterpreter>

{
public:

	GZ_DECLARE_TYPE_INTERFACE_EXPORT(GZ_BASE_EXPORT);

	GZ_BASE_EXPORT	gzHTTPInterpreter();

	GZ_BASE_EXPORT	virtual ~gzHTTPInterpreter();

	// -------------- Properties -------------------

	GZ_PROPERTY_GET_EXPORT(gzString, User, GZ_BASE_EXPORT);
	GZ_PROPERTY_GET_EXPORT(gzString, Password, GZ_BASE_EXPORT);
	GZ_PROPERTY_GET_EXPORT(gzUInt16, HostPort, GZ_BASE_EXPORT);
	GZ_PROPERTY_GET_EXPORT(gzString, Host, GZ_BASE_EXPORT);
	GZ_PROPERTY_GET_EXPORT(gzString, Path, GZ_BASE_EXPORT);

	GZ_PROPERTY_EXPORT(gzString, AttributeString, GZ_BASE_EXPORT);
	GZ_PROPERTY_EXPORT(gzUInt32, MajorVersion, GZ_BASE_EXPORT);
	GZ_PROPERTY_EXPORT(gzUInt32, MinorVersion, GZ_BASE_EXPORT);
	GZ_PROPERTY_EXPORT(gzString, UserAgent, GZ_BASE_EXPORT);

	GZ_PROPERTY_EXPORT(gzString, DefaultUser, GZ_BASE_EXPORT);
	GZ_PROPERTY_EXPORT(gzUInt16, DefaultHostPort, GZ_BASE_EXPORT);


	GZ_PROPERTY_GET_EXPORT(gzUInt32, LastContentLength, GZ_BASE_EXPORT);
	GZ_PROPERTY_GET_EXPORT(gzString, LastContentType, GZ_BASE_EXPORT);
	GZ_PROPERTY_GET_EXPORT(gzString, LastContentBase, GZ_BASE_EXPORT);
	GZ_PROPERTY_GET_EXPORT(gzUInt32, LastErrorCode, GZ_BASE_EXPORT);

	//GZ_PROPERTY_EXPORT(gzBool, BlockingRead, GZ_BASE_EXPORT);

	//GZ_PROPERTY_EXPORT(gzBool, PacketMessageBody, GZ_BASE_EXPORT);

	//GZ_PROPERTY_EXPORT(gzString, NicAddress, GZ_BASE_EXPORT);

	GZ_BASE_EXPORT	gzBool	hasPublicMethod(const gzString &methodName);
	GZ_BASE_EXPORT	gzVoid	addPublicMethod(const gzString &methodName);
	GZ_BASE_EXPORT  gzBool checkMethod(const gzString &methodName);

	GZ_BASE_EXPORT	gzVoid	resetLastError();

	// Errors
	GZ_BASE_EXPORT virtual gzString			getErrorMessage(gzUInt32 errorCode) const;

	// ---------- Parse utils --------------

	GZ_BASE_EXPORT virtual gzParseResult parseRule(const gzString &rule) override;


	// parsing

	GZ_BASE_EXPORT virtual gzParseResult parseMessage();
	GZ_BASE_EXPORT virtual gzParseResult parseMessageBody();
	GZ_BASE_EXPORT virtual gzParseResult parseRequest();
	GZ_BASE_EXPORT virtual gzParseResult parseRequestLine();
	GZ_BASE_EXPORT virtual gzParseResult parseRequestHeader();
	GZ_BASE_EXPORT virtual gzParseResult parseRequestURI();
	GZ_BASE_EXPORT virtual gzParseResult parseResponse();
	GZ_BASE_EXPORT virtual gzParseResult parseResponseHeader();
	GZ_BASE_EXPORT virtual gzParseResult parseGeneralHeader();
	GZ_BASE_EXPORT virtual gzParseResult parseEntityHeader();
	GZ_BASE_EXPORT virtual gzParseResult parseStatusLine();
	GZ_BASE_EXPORT virtual gzParseResult parseVersion();
	GZ_BASE_EXPORT virtual gzParseResult parseStatusCode();
	GZ_BASE_EXPORT virtual gzParseResult parseReasonPhrase();
	GZ_BASE_EXPORT virtual gzParseResult parseWWWAuthenticate();
	GZ_BASE_EXPORT virtual gzParseResult parseAllow();
	GZ_BASE_EXPORT virtual gzParseResult parseContentBase();
	GZ_BASE_EXPORT virtual gzParseResult parseContentEncoding();
	GZ_BASE_EXPORT virtual gzParseResult parseContentLanguage();
	GZ_BASE_EXPORT virtual gzParseResult parseContentLength();
	GZ_BASE_EXPORT virtual gzParseResult parseContentLocation();
	GZ_BASE_EXPORT virtual gzParseResult parseContentType();
	GZ_BASE_EXPORT virtual gzParseResult parseExpires();
	GZ_BASE_EXPORT virtual gzParseResult parseLastModified();
	GZ_BASE_EXPORT virtual gzParseResult parseExtensionHeader();
	GZ_BASE_EXPORT virtual gzParseResult parseCacheControl();
	GZ_BASE_EXPORT virtual gzParseResult parseConnection();
	GZ_BASE_EXPORT virtual gzParseResult parseDate();
	GZ_BASE_EXPORT virtual gzParseResult parseVia();
	GZ_BASE_EXPORT virtual gzParseResult parseProductOrComment();
	GZ_BASE_EXPORT virtual gzParseResult parseServer();
	GZ_BASE_EXPORT virtual gzParseResult parseVary();
	GZ_BASE_EXPORT virtual gzParseResult parseRetryAfter();
	GZ_BASE_EXPORT virtual gzParseResult parsePublic();
	GZ_BASE_EXPORT virtual gzParseResult parseProxyAuthenticate();
	GZ_BASE_EXPORT virtual gzParseResult parseLocation();
	GZ_BASE_EXPORT virtual gzParseResult parseMethod();
	GZ_BASE_EXPORT virtual gzParseResult parseExtensionMethod();
	GZ_BASE_EXPORT virtual gzParseResult parseMethodList();
	GZ_BASE_EXPORT virtual gzParseResult parseCacheDirectiveList();
	GZ_BASE_EXPORT virtual gzParseResult parseCacheDirective();
	GZ_BASE_EXPORT virtual gzParseResult parseCacheResponse();
	GZ_BASE_EXPORT virtual gzParseResult parseCacheRequest();
	GZ_BASE_EXPORT virtual gzParseResult parseFieldNameList();

	// Basics

	GZ_BASE_EXPORT gzParseResult parseToken();

	// Compounds

	GZ_BASE_EXPORT gzParseResult parseDigit_();
	GZ_BASE_EXPORT gzParseResult parseHEX_();
	GZ_BASE_EXPORT gzParseResult parseToken_();
	GZ_BASE_EXPORT gzParseResult parseTokenOrSP_();
	GZ_BASE_EXPORT gzParseResult parseLWS();
	GZ_BASE_EXPORT gzParseResult parseLWS_();
	GZ_BASE_EXPORT gzParseResult parseText();
	GZ_BASE_EXPORT gzParseResult parseText_();
	GZ_BASE_EXPORT gzParseResult parseTSpecials();
	GZ_BASE_EXPORT gzParseResult parseCText();
	GZ_BASE_EXPORT gzParseResult parseComment();
	GZ_BASE_EXPORT gzParseResult parseDQText();
	GZ_BASE_EXPORT gzParseResult parseDQString();
	GZ_BASE_EXPORT gzParseResult parseAbsoluteURI();
	GZ_BASE_EXPORT gzParseResult parseReserved();
	GZ_BASE_EXPORT gzParseResult parseScheme();
	GZ_BASE_EXPORT gzParseResult parseScheme_();
	GZ_BASE_EXPORT gzParseResult parseUChar();
	GZ_BASE_EXPORT gzParseResult parseEscape();
	GZ_BASE_EXPORT gzParseResult parseUnreserved();
	GZ_BASE_EXPORT gzParseResult parseSafe();
	GZ_BASE_EXPORT gzParseResult parseUnsafe();
	GZ_BASE_EXPORT gzParseResult parseExtra();
	GZ_BASE_EXPORT gzParseResult parseNational();
	GZ_BASE_EXPORT gzParseResult parseMediaType();
	GZ_BASE_EXPORT gzParseResult parseParameter();
	GZ_BASE_EXPORT gzParseResult parseHost();
	GZ_BASE_EXPORT gzParseResult parseHostName();
	GZ_BASE_EXPORT gzParseResult parseDomainLabel();
	GZ_BASE_EXPORT gzParseResult parseTopLabel();
	GZ_BASE_EXPORT gzParseResult parseProduct();
	GZ_BASE_EXPORT gzParseResult parseAbsPath();
	GZ_BASE_EXPORT gzParseResult parsePathSegments();
	GZ_BASE_EXPORT gzParseResult parseAuthority();
	GZ_BASE_EXPORT gzParseResult parseSegment();
	GZ_BASE_EXPORT gzParseResult parseParam();
	GZ_BASE_EXPORT gzParseResult parsePChar();


private:

	gzDict<gzString, gzVoid>		m_publicMethods;

	gzQueue<gzParseHttpState>	m_currentState;

};

GZ_DECLARE_REFPTR(gzHTTPInterpreter);

#endif //__GZ_INTERPRETER_H__
