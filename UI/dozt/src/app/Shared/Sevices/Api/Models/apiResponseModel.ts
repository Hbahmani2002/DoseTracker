export class apiResponseModel {
  data: any
  exception: any
  extraData: any
  hasError: boolean
  message: string
  type: string
  typeVal: number

  static parse(data: any): apiResponseModel {    
    let d = Object.assign(new apiResponseModel(), data)
    return d;

  }
}
