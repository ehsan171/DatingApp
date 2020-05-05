import { EpisodeTitle } from './episodeTitle';
import { Producer } from './producer';

export interface Screenplay {
    id: number;
    title: string;
    orgStructure?: string;
    status?: string;
    episodeTitles?: EpisodeTitle[];
    genre?: string;
    producers?: Producer[];
    writers?: string;
}
