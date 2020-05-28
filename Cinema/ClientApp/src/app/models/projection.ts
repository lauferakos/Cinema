import { Film } from "./film";

export interface Projection {
  id: number;
  filmId: number;
  film: Film;
  roomId: number;
  start: Date;
}
