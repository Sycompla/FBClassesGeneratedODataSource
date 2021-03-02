
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using CSUsers;
using FBClassesCap;

namespace  FBClassesObjectService
{
 
    public class UserTokenObjectService
    {
        public GetListResponse GetList(GetListRequest request)
        {

            GetListResponse response = new GetListResponse();

            try
            {

                response.UserTokens = new UserTokenCap().GetList();

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

                response.UserToken = new UserTokenCap().GetById(request.Id);

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

                response.UserToken = new UserTokenCap().GetByGuid(request.Guid);

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

                if (new UserTokenCap().IsExistById(request.Id))
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

                if (new UserTokenCap().IsExistByGuid(request.Guid))
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
                if (new UserTokenCap().IsExistById(request.Id)) { 

                    UserToken responseUserToken = new UserTokenCap().UpdateById(request.Id, request.UserToken);

                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
		    response.UserToken = responseUserToken;
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
                if (new UserTokenCap().IsExistByGuid(request.Guid)) { 

                    new UserTokenCap().UpdateByGuid(request.Guid, request.UserToken);

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

                UserToken responseUserToken = new UserTokenCap().Insert(request.UserToken);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
		response.UserToken = responseUserToken;

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
                              UserToken = request.UserToken
                          });

                  response.Result = updateByGuidResponse.Result;

              }
              else
              {

                  InsertResponse insertResponse =
                      Insert(
                          new InsertRequest()
                          {
                              UserToken = request.UserToken
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
                if (new UserTokenCap().IsExistById(request.Id)) { 

                    new UserTokenCap().DeleteById(request.Id);

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
            public IEnumerable<UserToken> UserTokens { get; set; }
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
            public UserToken UserToken { get; set; }
        }

        public class GetByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
        }

        public class GetByGuidResponse : Ac4yServiceResponse
        {
            public UserToken UserToken { get; set; }
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
            public UserToken UserToken { get; set; }
        }

        public class UpdateByIdResponse : Ac4yServiceResponse 
	{
		public UserToken UserToken { get; set; }
	}

        public class UpdateByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
            public UserToken UserToken { get; set; }
        }

        public class UpdateByGuidResponse : Ac4yServiceResponse 
	{
		public UserToken UserToken { get; set; }
	}

        public class InsertRequest : Ac4yServiceRequest
        {
            public UserToken UserToken { get; set; }
        }

        public class InsertResponse : Ac4yServiceResponse 
	{
		public UserToken UserToken { get; set; }
	}

        public class SetByGuidRequest : Ac4yServiceRequest
        {
            public string Guid { get; set; }
            public UserToken UserToken { get; set; }
        }

        public class SetByGuidResponse : Ac4yServiceResponse {}

        public class DeleteByIdResponse : Ac4yServiceResponse
        {

        }

        public class DeleteByIdRequest : Ac4yServiceRequest
        {
            public int Id { get; set; }
        }

    } // UserTokenObjectService

} // ObjectService
