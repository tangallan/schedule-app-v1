import { Deserializable } from '../../../../shared/interfaces/deserializable';

export class VendorService implements Deserializable {
  id: number;
  vendorId: string;
  serviceType: string;
  timeScaleTotal: number;
  timeScale = '';
  price: number;

  deserialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
