import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
    clientId: 'bf0472af-3e91-4a31-993f-5aed0cab83d1',
    responseType: 'code',
    useSilentRefresh: true,
    redirectUri: window.location.origin + '/home',
    postLogoutRedirectUri: 'https://localhost:4200/login',
    fallbackAccessTokenExpirationTimeInSec: 3600,
    scope: 'openid api://c8b7fa4c-afe3-473f-9247-b4ebd27dcf6a/access_as_user',
    requireHttps: true,
    showDebugInformation: true,
    issuer: 'https://login.microsoftonline.com/147a2b71-5ce9-4933-94c4-2054328de565/v2.0',
    strictDiscoveryDocumentValidation: false
};
