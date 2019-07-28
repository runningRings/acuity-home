export * from './url.service';
export * from './auth.service';

import { UrlBuilderFactory } from './url.service';
import { AuthService } from './auth.service';

export const SERVICES = [AuthService, UrlBuilderFactory];
