﻿using System;
namespace Shared.Entities.ComplexTypes
{
    public enum HttpStatusCode
    {
        OK=200,
        Created=201,
        Accepted=202,
        NoContent=204,
        BadRequest=400,
        UnAuthorized=401,
        Forbidden=403,
        NotFound=404,
        InternalServerError=500,
        NotImplemented=501,
        BadGateWay=502,
        ServiceUnAvailable=503,
        GatewayTimeout=504
    }
}

