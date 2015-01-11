<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
		<head>
			<title>Test Run Results</title>
			</head>
			<body>
				<table border="1">
					<tr>
						<td>Request URL</td>
						<td>Port</td>
						<td>Method</td>
						<td>Redponse Code</td>
						<td>Start Time</td>
						<td>End Time</td>
					</tr>
					<xsl:for-each select="GenericDataCollectionOfRequestInfo/Item">
						<tr>
							<td>
								<xsl:value-of select="RequestAddress"/>
							</td>
							<td>
								<xsl:value-of select="RequestPort"/>
							</td>
							<td>
								<xsl:value-of select="RequestType"/>
							</td>
							<td>
								<xsl:value-of select="ResponseCode"/>
							</td>
							<td>
								<xsl:value-of select="StartTime"/>
							</td>
							<td>
								<xsl:value-of select="EndTime"/>
							</td>
						</tr>
				</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>