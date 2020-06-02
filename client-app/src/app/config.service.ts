import { Injectable } from '@angular/core';
import { IAppConfig } from './config';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  appConfig: IAppConfig;
  constructor() { }
}
