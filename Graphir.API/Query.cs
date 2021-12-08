﻿using Graphir.API.Services;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using static Hl7.Fhir.Model.Bundle;
using System.Linq;

namespace Graphir.API
{
    public class Query
    {
        private readonly FhirClient _fhirService;

        public Query(FhirClient fhirService)
        {
            _fhirService = fhirService;
        }

        public async Task<string> Meta()
        {
            var meta = await _fhirService.CapabilityStatementAsync();

            return JsonConvert.SerializeObject(meta);
        }

        public string GetMe(ClaimsPrincipal principal)
        {
            return principal.Identity.Name;
        }               

    }    
}
