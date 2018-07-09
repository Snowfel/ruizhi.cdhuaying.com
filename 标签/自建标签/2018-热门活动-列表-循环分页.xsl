<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="outputQty" />
    <xsl:param name="titleLength" />
    <xsl:param name="eliteLevel" />
    <xsl:param name="hits" />
    <xsl:param name="linkOpenType" />
    <xsl:param name="nodeid" />
    <xsl:param name="isnew" />
    <xsl:output method="html" />
    <xsl:template match="/">
        <NewDataSet>
            <xsl:for-each select="NewDataSet/Table">
                <Table>
                    <GeneralID>
                        <xsl:value-of select="GeneralID"/>
                    </GeneralID>
                    <ItemId>
                        <xsl:value-of select="ItemId"/>
                    </ItemId>
                    <Title>
                        <xsl:value-of select="pe:CutText(pe:RemoveHtml(Title),$titleLength,'…')" />
                    </Title>
                    <DefaultPicUrl>
                        &lt;img src="<xsl:value-of select="pe:UpLoadDir()"/>
                        <xsl:value-of select="DefaultPicUrl"/>" alt="<xsl:value-of select="Title"/>" border="0" /&gt;
                    </DefaultPicUrl>
                    <RedirectLink>
                        <xsl:value-of select="RedirectLink" />
                    </RedirectLink>
                    <Intro>
                        <xsl:value-of select="Intro" />
                    </Intro>
                    <InfoPath>
                        &lt;div class="col-sm-4"&gt;
                        &lt;div class="card"&gt;
                        &lt;div class="card-body"&gt;
                        &lt;img class="card-img-top" src="<xsl:value-of select="pe:UpLoadDir()"/><xsl:value-of select="DefaultPicUrl"/>" alt="<xsl:value-of select="Title" />"&gt;
                        &lt;h3 class="card-title"&gt;<xsl:value-of select="Title" />&lt;/h3&gt;
                        &lt;p class="card-text"&gt;<xsl:value-of select="pe:CutText(pe:RemoveHtml(intro),$titleLength,'…')" disable-output-escaping="yes" />&lt;/p&gt;
                        &lt;a href="<xsl:value-of select="RedirectLink" />" target="_blank" class="btn btn-primary float-right d-inline-block px-4"&gt;了解详情&lt;/a&gt;
                        &lt;/div&gt;
                        &lt;/div&gt;
                        &lt;/div&gt;
                    </InfoPath>
                </Table>
            </xsl:for-each>
        </NewDataSet>
    </xsl:template>
</xsl:stylesheet>