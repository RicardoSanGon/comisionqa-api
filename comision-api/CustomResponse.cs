namespace comision_api
{
    public class CustomResponse
    {
        private Object data;
        public CustomResponse(Object data)
        {
            this.data = data;
        }

        public Object ok()
        {
            return new
            {
                status = 200,
                data = this.data
            };
        }

        public Object error()
        {
            return new
            {
                status = 500,
                data = this.data
            };
        }

        public Object notFound()
        {
            return new
            {
                status = 404,
                message = this.data
            };
        }

        public Object created()
        {
            return new
            {
                status = 201,
                data = this.data
            };
        }

        public Object badRequest()
        {
            return new
            {
                status = 400,
                data = this.data
            };
        }

        public Object updated()
        {
            return new
            {
                status = 200,
                data = this.data
            };
        }
    }
}
