import { Injectable } from '@angular/core';
import * as _ from 'lodash';

export class UrlBuilderService {
  private readonly baseUrl: string;
  private readonly urlParts: Array<string>;
  private readonly queryParameters: object;

  constructor(baseUrl: string, parts: Array<string>, params: object) {
    this.baseUrl = baseUrl;
    this.urlParts = parts == null ? new Array<string>() : parts;
    this.queryParameters = params == null ? {} : params;
  }

  addPart(part): UrlBuilderService {
    if (part.startsWith('/')) {
      part.slice(1, part.length);
    }

    this.urlParts.push(this.removeTrailingSlash(part));
    return this;
  }

  addParts(parts: Array<string>): UrlBuilderService {
    parts.forEach(part => {
      this.addPart(part);
    });

    return this;
  }

  addParameter(key, value): UrlBuilderService {
    this.queryParameters[key] = value;
    return this;
  }

  addParameters(params: Object): UrlBuilderService {
    Object.keys(params).forEach(key => {
      this.addParameter(key, params[key]);
    });

    return this;
  }

  build(): URL {
    let base = this.addTrailingSlash(this.baseUrl);

    this.urlParts.forEach((part, index, arr) => {
      if (index !== arr.length - 1) {
        base += this.addTrailingSlash(part);
      } else {
        base += part;
      }
    });

    if (Object.keys(this.queryParameters).length >= 1) {
      base = this.removeTrailingSlash(base);
    }

    let params = '';

    _.sortBy(Object.keys(this.queryParameters)).forEach(key => {
      if (params === '') {
        params += `${key}=${this.queryParameters[key]}`;
      } else {
        params += `&${key}=${this.queryParameters[key]}`;
      }
    });

    if (params !== '') {
      base += `?${params}`;
    }

    return new URL(base);
  }

  private addTrailingSlash(value) {
    if (!value.endsWith('/')) {
      value += '/';
    }

    return value;
  }

  private removeTrailingSlash(value) {
    if (value.endsWith('/')) {
      value = value.slice(0, value.length - 1);
    }

    return value;
  }
}

@Injectable()
export class UrlBuilderFactory {
  create(root: string, parts?: Array<string>, params?: object): UrlBuilderService {
    return new UrlBuilderService(root, parts, params);
  }
}
