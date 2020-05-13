import { EpisodeTitle } from './episodeTitle';
import { Producer } from './producer';
import { Writer } from './writer';

export interface Screenplay {
    id: number;
    title: string;
    orgStructure?: string;
    status?: string;
    episodeTitles?: EpisodeTitle[];
    genre?: string;
    producers?: Producer[];
    writers?: Writer[];
    baravordNo?: string;
    totalNumberEpisodes?: number;
    format?: string;
    
}
