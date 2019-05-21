import { Deserializable } from '../../../../shared/interfaces/deserializable';

export class VendorAvailability implements Deserializable {
    id: Number;
    vendorId: String;
    dayOfWeek: Number;
    fromTime: String;
    toTime: String

    deserialize(input: any): this {
        Object.assign(this, input);
        return this;
    }
}