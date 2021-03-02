
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using CSUsers;
using FBClassesCap;

namespace  FBClassesObjectService
{
 
    public class UserObjectService
    {
        public GetListResponse GetList(GetListRequest request)
        {

            GetListResponse response = new GetListResponse();

            try
            {

                response.Users = new UserCap().GetList();

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        }

        public GetByIdResponse GetById(GetByIdRequest request)
        {

            GetByIdResponse response = new GetByIdResponse();

            try
            {

                response.User = new UserCap().GetById(request.Id);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // GetById
/*
        public GetByGuidResponse GetByGuid(GetByGuidRequest request)
        {

            GetByGuidResponse response = new GetByGuidResponse();

            try
            {

                response.User = new UserCap().GetByGuid(request.Guid);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // GetByGuid
*/
        public IsExistByIdResponse IsExistById(IsExistByIdRequest request)
        {
            IsExistByIdResponse response = new IsExistByIdResponse();

            try
            {

                if (new UserCap().IsExistById(request.Id))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // IsExistById
/*
        public IsExistByGuidResponse IsExistByGuid(IsExistByGuidRequest request)
        {

            IsExistByGuidResponse response = new IsExistByGuidResponse();

            try
            {

                if (new UserCap().IsExistByGuid(request.Guid))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE };

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // IsExistByGuid
*/
        public UpdateByIdResponse UpdateById(UpdateByIdRequest request)
        {

            UpdateByIdResponse response = new UpdateByIdResponse();

            try
            {
                if (new UserCap().IsExistById(request.Id)) { 

                    User responseUser = new UserCap().UpdateById(request.Id, request.User);

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
		    response.User = responseUser;
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Adott id-val nem létezik rekord." };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // UpdateById
/*
        public UpdateByGuidResponse UpdateByGuid(UpdateByGuidRequest request)
        {

            UpdateByGuidResponse response = new UpdateByGuidResponse();

            try
            {
                if (new UserCap().IsExistByGuid(request.Guid)) { 

                    new UserCap().UpdateByGuid(request.Guid, request.User);

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Adott id-val nem létezik rekord." };
                }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // UpdateByGuid
*/
        public InsertResponse Insert(InsertRequest request)
        {

            InsertResponse response = new InsertResponse();

            try
            {

                User responseUser = new UserCap().Insert(request.User);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
		response.User = responseUser;

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // Insert
/*
        public SetByGuidResponse SetByGuid(SetByGuidRequest request)
        {

            SetByGuidResponse response = new SetByGuidResponse();

            try
            {

              IsExistByGuidResponse isExistByGuidResponse =
                  IsExistByGuid(new IsExistByGuidRequest() { Guid = request.Guid } );

              if (isExistByGuidResponse.Result.Success())
              {

                  UpdateByGuidResponse updateByGuidResponse =
                      UpdateByGuid(
                          new UpdateByGuidRequest()
                          {
                              Guid = request.Guid
                              ,
                              User = request.User
                          });

                  response.Result = updateByGuidResponse.Result;

              }
              else
              {

                  InsertResponse insertResponse =
                      Insert(
                          new InsertRequest()
                          {
                              User = request.User
                          });

                  response.Result = insertResponse.Result;

              }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // SetByGuid
        */
        public DeleteByIdResponse DeleteById(DeleteByIdRequest request)
        {

            DeleteByIdResponse response = new DeleteByIdResponse();

            try
            {
                if (new UserCap().IsExistById(request.Id)) { 

                    new UserCap().DeleteById(request.Id);

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Adott id-val nem létezik rekord." };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }

            return response;

        } // DeleteById
        public class GetListResponse : Ac4yServiceResponse
        {
            public IEnumerable<User> Users { get; set; }
        }

        public class GetListRequest : Ac4yServiceRequest
        {

        }
        
        public class GetByIdRequest : Ac4yServiceRequest
        {
            public int Id { get; set; }
        }

        public class GetByIdResponse : Ac4yServiceResponse
        {
            public User User { get; set; }
        }

        public class GetByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
        }

        public class GetByGuidResponse : Ac4yServiceResponse
        {
            public User User { get; set; }
        }

        public class IsExistByIdRequest : Ac4yServiceRequest
        {
            public int Id { get; set; }
        }

        public class IsExistByIdResponse : Ac4yServiceResponse {}

        public class IsExistByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
        }

        public class IsExistByGuidResponse : Ac4yServiceResponse {}

        public class UpdateByIdRequest : Ac4yServiceRequest
        {
            public int Id { get; set; }
            public User User { get; set; }
        }

        public class UpdateByIdResponse : Ac4yServiceResponse 
	{
		public User User { get; set; }
	}

        public class UpdateByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
            public User User { get; set; }
        }

        public class UpdateByGuidResponse : Ac4yServiceResponse 
	{
		public User User { get; set; }
	}

        public class InsertRequest : Ac4yServiceRequest
        {
            public User User { get; set; }
        }

        public class InsertResponse : Ac4yServiceResponse 
	{
		public User User { get; set; }
	}

        public class SetByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
            public User User { get; set; }
        }

        public class SetByGuidResponse : Ac4yServiceResponse {}

        public class DeleteByIdResponse : Ac4yServiceResponse
        {

        }

        public class DeleteByIdRequest : Ac4yServiceRequest
        {
            public int Id { get; set; }
        }

    } // UserObjectService

} // ObjectService
