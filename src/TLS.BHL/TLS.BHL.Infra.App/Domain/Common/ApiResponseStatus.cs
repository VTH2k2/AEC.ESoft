namespace AEC.ESoft.Infra.App.Domain.Common
{
    public static class ApiResponseStatus
    {
        /// <summary>
        /// 200: Success
        /// </summary>
        public static int Success
        {
            get
            {
                return StatusInternal.Success.GetHashCode();
            }
        }

        /// <summary>
        /// 999: Error
        /// </summary>
        public static int Error
        {
            get
            {
                return StatusInternal.Error.GetHashCode();
            }
        }

        private enum StatusInternal
        {
            /// <summary>
            /// 200: Success
            /// </summary>
            Success = 200,

            /// <summary>
            /// Errror
            /// </summary>
            Error = 999
        }
    }
}
