import { Deserializable } from '../../../../shared/interfaces/deserializable';
import { VendorResult } from './vendorResult';

export class VendorServiceResult implements Deserializable {

  id: number;
  vendorId: string;
  serviceType: string;
  timeScaleTotal: number;
  timeScale: string;
  price: number;

  vendor: VendorResult;


  deserialize(input: any): this {
    Object.assign(this, input);

    this.vendor = new VendorResult().deserialize(input.vendor);

    return this;
  }

}
