import { Seat } from "./seat";

export interface Room {
  id: number;
  capacity: number;
  seats: Seat[];
}
