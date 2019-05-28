import { Deserializable } from 'src/app/shared/interfaces/deserializable';

export class VendorResult implements Deserializable {

  id: string;
  firstName: string;
  lastName: string;
  companyName: string;

  deserialize(input: any): this {
    Object.assign(this, input);
    return this;
  }
}
