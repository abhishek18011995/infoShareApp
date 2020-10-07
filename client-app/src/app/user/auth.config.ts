import { AuthConfig } from 'angular-oauth2-oidc';

// Azure Ad IDP
// export const authConfig: AuthConfig = {
//     clientId: 'bf0472af-3e91-4a31-993f-5aed0cab83d1',
//     responseType: 'code',
//     useSilentRefresh: true,
//     redirectUri: window.location.origin + '/home',
// postLogoutRedirectUri: window.location.origin + '/login',
//     fallbackAccessTokenExpirationTimeInSec: 3600,
//     scope: 'openid api://c8b7fa4c-afe3-473f-9247-b4ebd27dcf6a/access_as_user',
//     requireHttps: true,
//     showDebugInformation: true,
//     issuer: 'https://login.microsoftonline.com/147a2b71-5ce9-4933-94c4-2054328de565/v2.0',
//     strictDiscoveryDocumentValidation: false
// };

// Auth0 IDP
export const authConfig: AuthConfig = {
    clientId: 'AgWM8ssykw8xgSEd5qJ214MXZIUTYdAo',
    responseType: 'code',
    useSilentRefresh: true,
    redirectUri: window.location.origin + '/home',
    postLogoutRedirectUri: window.location.origin + '/login',
    fallbackAccessTokenExpirationTimeInSec: 3600,
    scope: 'openid info_app_api',
    requireHttps: true,
    showDebugInformation: true,
    issuer: 'https://dev-y02mpd7s.auth0.com/',
    strictDiscoveryDocumentValidation: true,
    customQueryParams: {
        audience: 'https://localhost:44366/api/',
      }
};
