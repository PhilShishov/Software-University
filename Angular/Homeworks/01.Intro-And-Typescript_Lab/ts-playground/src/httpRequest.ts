interface IRequest {
  method: string;
  uri: string;
  version: string;
  message: string;
}

class Requester implements IRequest {
  public response: string = 'undefined';
  public fulfilled: boolean = false;

  constructor(
    public method: string,
    public uri: string,
    public version: string,
    public message: string,
  ) {}
}

export default Requester;