/* tslint:disable */
/* eslint-disable */
/**
 * SongGuessBackend
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface Song
 */
export interface Song {
    /**
     * 
     * @type {number}
     * @memberof Song
     */
    id: number;
    /**
     * 
     * @type {string}
     * @memberof Song
     */
    songId?: string;
    /**
     * 
     * @type {string}
     * @memberof Song
     */
    songName: string;
    /**
     * 
     * @type {string}
     * @memberof Song
     */
    songPath: string;
    /**
     * 
     * @type {number}
     * @memberof Song
     */
    songLength?: number;
    /**
     * 
     * @type {string}
     * @memberof Song
     */
    songAlbum?: string | null;
    /**
     * 
     * @type {string}
     * @memberof Song
     */
    songMime?: string | null;
}

/**
 * Check if a given object implements the Song interface.
 */
export function instanceOfSong(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "id" in value;
    isInstance = isInstance && "songName" in value;
    isInstance = isInstance && "songPath" in value;

    return isInstance;
}

export function SongFromJSON(json: any): Song {
    return SongFromJSONTyped(json, false);
}

export function SongFromJSONTyped(json: any, ignoreDiscriminator: boolean): Song {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'id': json['id'],
        'songId': !exists(json, 'songId') ? undefined : json['songId'],
        'songName': json['songName'],
        'songPath': json['songPath'],
        'songLength': !exists(json, 'songLength') ? undefined : json['songLength'],
        'songAlbum': !exists(json, 'songAlbum') ? undefined : json['songAlbum'],
        'songMime': !exists(json, 'songMime') ? undefined : json['songMime'],
    };
}

export function SongToJSON(value?: Song | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'id': value.id,
        'songId': value.songId,
        'songName': value.songName,
        'songPath': value.songPath,
        'songLength': value.songLength,
        'songAlbum': value.songAlbum,
        'songMime': value.songMime,
    };
}
