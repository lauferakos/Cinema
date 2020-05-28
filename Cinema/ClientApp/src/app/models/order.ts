import { Projection } from "./projection";

export interface Order {
  id?: number;
  projectionId: number;
  projection?: Projection;
  price: number;
  reservedSeats: number;
  viewerId: number;
}
