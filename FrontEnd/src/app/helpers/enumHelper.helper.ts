export default class EnumHelper {
    static getEnumList(objectType: any) { return Object.values(objectType).filter((o) => typeof o == 'number'); }
}