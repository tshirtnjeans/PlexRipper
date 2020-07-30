import IPlexTvShow from './IPlexTvShow';
import IPlexMovie from './IPlexMovie';

export default interface IPlexLibrary {
	id: number;
	key: string;
	title: string;
	type: 'movie' | 'show';
	updatedAt: Date;
	createdAt: Date;
	scannedAt: Date;
	contentChangedAt: Date;
	uuid: string;
	libraryLocationId: number;
	libraryLocationPath: string;
	plexServerId: number;
	count: number;
	movies?: IPlexMovie[] | undefined;
	tvShows?: IPlexTvShow[] | undefined;
}
